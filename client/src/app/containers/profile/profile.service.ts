import { Injectable } from '@angular/core';
import { UserService } from 'src/app/shared/services/user.service';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private _http: HttpClient, private user: UserService) { }
  
  fetch(filters): Observable<any[]> {
    let p = {
      ...filters,
      ...{username: this.user.getUser()}
    }
    return this._http.get<any[]>(`${environment.api}Users/${this.user.getUser()}/Ratings`, { params: p });
  }
}
