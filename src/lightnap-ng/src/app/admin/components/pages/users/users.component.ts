import { AdminUser, SearchAdminUsersSortBy } from "@admin";
import { AdminService } from "@admin/services/admin.service";
import { CommonModule } from "@angular/common";
import { Component, inject } from "@angular/core";
import { takeUntilDestroyed } from "@angular/core/rxjs-interop";
import { FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { RouterModule } from "@angular/router";
import { ApiResponseComponent, ConfirmPopupComponent, EmptyPagedResponse, ErrorListComponent, ListItem, ToastService } from "@core";
import { RoutePipe } from "@routing";
import { ConfirmationService } from "primeng/api";
import { ButtonModule } from "primeng/button";
import { PanelModule } from 'primeng/panel';
import { InputTextModule } from "primeng/inputtext";
import { TableLazyLoadEvent, TableModule } from "primeng/table";
import { TagModule } from "primeng/tag";
import { debounceTime, startWith, Subject, switchMap } from "rxjs";

@Component({
  standalone: true,
  templateUrl: "./users.component.html",
  imports: [
    CommonModule,
    ReactiveFormsModule,
    PanelModule,
    ApiResponseComponent,
    TableModule,
    ButtonModule,
    RouterModule,
    RoutePipe,
    ErrorListComponent,
    InputTextModule,
    ConfirmPopupComponent,
    TagModule,
  ],
})
export class UsersComponent {
  readonly pageSize = 25;

  readonly #adminService = inject(AdminService);
  readonly #confirmationService = inject(ConfirmationService);
  readonly #toast = inject(ToastService);
  readonly #fb = inject(FormBuilder);

  readonly form = this.#fb.group({
    email: this.#fb.control(""),
    userName: this.#fb.control(""),
  });

  errors = new Array<string>();

  readonly #lazyLoadEventSubject = new Subject<TableLazyLoadEvent>();
  readonly users$ = this.#lazyLoadEventSubject.pipe(
    switchMap(event =>
      this.#adminService.searchUsers({
        sortBy: (event.sortField as SearchAdminUsersSortBy) ?? "userName",
        reverseSort: event.sortOrder === -1,
        pageSize: this.pageSize,
        pageNumber: (event.first ?? 0) / this.pageSize + 1,
        email: this.form.value.email?.length ?? 0 > 0 ? this.form.value.email! : undefined,
        userName: this.form.value.userName?.length ?? 0 > 0 ? this.form.value.userName! : undefined,
      })
    ),
    // We need to bootstrap the p-table with a response to get the whole process running. We do it this way to fake an empty response
    // so we can avoid a redundant call to the API.
    startWith(new EmptyPagedResponse<AdminUser>())
  );

  sortBys = [
    new ListItem<SearchAdminUsersSortBy>("userName", "User Name", "Sort by user name."),
    new ListItem<SearchAdminUsersSortBy>("email", "Email", "Sort by email."),
    new ListItem<SearchAdminUsersSortBy>("createdDate", "Created", "Sort by created date."),
    new ListItem<SearchAdminUsersSortBy>("lastModifiedDate", "Last Modified", "Sort by last modified date."),
  ];

  constructor() {
    this.form.valueChanges.pipe(takeUntilDestroyed(), debounceTime(1000)).subscribe(() => {
      this.#lazyLoadEventSubject.next({ first: 0 });
    });
  }

  loadUsersLazy(event: TableLazyLoadEvent) {
    this.#lazyLoadEventSubject.next(event);
  }

  deleteUser(event: any, userId: string) {
    this.#confirmationService.confirm({
      header: "Confirm Delete",
      message: `Are you sure that you want to delete this user?`,
      key: userId,
      target: event.target,
      accept: () => {
        this.#adminService.deleteUser(userId).subscribe({
          next: () => {
            this.#toast.success("User deleted successfully.");
            this.#lazyLoadEventSubject.next({ first: 0 });
          },
          error: response => (this.errors = response.errorMessages),
        });
      },
    });
  }
}
