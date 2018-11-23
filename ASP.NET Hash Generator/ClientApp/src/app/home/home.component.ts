import { Component, Inject, ViewChild } from "@angular/core";
import { HttpClient, HttpErrorResponse } from "@angular/common/http";
import { ErrorObservable } from "rxjs/observable/ErrorObservable";
import { map, catchError } from "rxjs/operators";
import { Form, NgForm } from "@angular/forms";
@Component({
  selector: "app-home",
  templateUrl: "./home.component.html"
})
export class HomeComponent {
  constructor(private http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
    this.actionUrl = `${this.actionUrl}api/home`;
  }
  @ViewChild("form") form: Form;
  actionUrl = "";
  passwordModel = {
    hashType: null,
    password: ""
  };
  hashedPasswordModel = {
    hashedPassword: ""
  };
  hashTypes = [
    { value: 0, type: "ASP.NET MVC" },
    { value: 1, type: "ASP.NET CORE" }
  ];
  copyText = "Copiar";
  getHashedPassword(form: NgForm) {
    console.log(form);
    if (form.valid) {
      this.http.post(this.actionUrl, this.passwordModel)
        .pipe(map((response: any) => response), catchError(this.handleError)).subscribe(result => {
          console.log(result);
          this.hashedPasswordModel.hashedPassword = result.hashedPassword;
        });
    }
  }
  copied(event) {
    this.copyText = "Copiado";
  }
  private handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      console.error("An error occurred:", error.error.message);
    } else {
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}` +
        `,also ${error.message}`
      );
      console.log((<any>error)._body);
    }
    return new ErrorObservable((<any>error)._body);
  }
}
