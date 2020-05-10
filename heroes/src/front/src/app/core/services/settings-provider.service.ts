import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppSettingsModel } from '../models/app-settings.model';

@Injectable({ providedIn: 'root' })
export class AppSettingsProvider {
  private _settings: AppSettingsModel;
  private _url: string;
  public _loaded = false;

  constructor(private http: HttpClient ) {
      this._url = '/assets/config/config.json';
  }

  public load(): Promise<any> {
      const headers = new HttpHeaders().set('X-Skip-Interceptor', '');
      return  this.http
        .get<AppSettingsModel>(this._url, {headers})
        .toPromise()
        .then((settings: AppSettingsModel) => {
          this._settings = settings;
          this._loaded = true;
        });
    }

  public get settings(): AppSettingsModel {
    return this._settings;
  }
}
