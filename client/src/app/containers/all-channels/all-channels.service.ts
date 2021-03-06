import { Injectable } from '@angular/core';
import { ChannelLink } from 'src/app/shared/interfaces/Channel';
import { HttpClient } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AllChannelsService {

  constructor(private http: HttpClient) { }
  public fetch(filters: any): Observable<ChannelLink[]> {
    return this.http.get<ChannelLink[]>(
      `${environment.api}Channels`, 
      { params: filters }
    );
  }
}
