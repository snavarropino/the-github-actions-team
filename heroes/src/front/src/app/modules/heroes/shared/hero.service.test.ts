import {Observable, of} from 'rxjs';
import {Injectable} from '@angular/core';
import {Hero} from './hero.model';
import {catchError, map, tap} from 'rxjs/operators';
import {MatSnackBar, MatSnackBarConfig} from '@angular/material';
import {TranslateService} from '@ngx-translate/core';
import {_} from '@biesbjerg/ngx-translate-extract/dist/utils/utils';
import {LoggerService} from '../../../core/services/logger.service';
import {AppConfig} from '../../../configs/app.config';
import {AngularFirestore, AngularFirestoreCollection, DocumentReference} from '@angular/fire/firestore';
import { HttpClient } from '@angular/common/http';
import { AppSettingsProvider } from 'src/app/core/services/settings-provider.service';

@Injectable({
  providedIn: 'root'
})
export class HeroServiceTest {
  // private _url: string;
  private _heros: Hero [] = [];

  static checkIfUserCanVote(): boolean {
    return Number(localStorage.getItem('votes')) < AppConfig.votesLimit;
  }

  constructor(private afs: AngularFirestore,
              private translateService: TranslateService,
              private snackBar: MatSnackBar) {
                this.PopulateHeros();
  }


  private static handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      LoggerService.log(`${operation} failed: ${error.message}`);

      if (error.status >= 500) {
        throw error;
      }

      return of(result as T);
    };
  }

  public getHeroes(): Observable<Hero[]> {
    return of(this._heros);
  }

  getHero(id: string): Observable<any> {
    return this.afs.doc(`${AppConfig.routes.heroes}/${id}`).get().pipe(
      map((hero) => {
        return new Hero({id, ...hero.data()});
      }),
      tap(() => LoggerService.log(`fetched hero ${id}`)),
      catchError(HeroServiceTest.handleError('getHero', []))
    );
  }

  createHero(hero: Hero): Promise<Hero> {

    const promise = new Promise<Hero>((resolve, reject) => {
      hero.id = `${Math.random()}`;
      this._heros.push(hero);
      resolve(hero);
    });

    return promise;
  }

  updateHero(hero: Hero): void {

    const index = this._heros.findIndex(x => x.id === hero.id);
    if (index !== -1) {
      this._heros[index] = hero;
    }
  }

  deleteHero(id: string): Promise<void> {

    const promise = new Promise<void>((resolve, reject) => {

      const index = this._heros.findIndex(x => x.id === id);
      if (index !== -1) {
        this._heros.splice(index, 1);
        resolve();
      }
    });

    return promise;
  }

  showSnackBar(name): void {
    this.translateService.get([String(_('heroCreated')), String(_('saved')),
      String(_('heroLikeMaximum')), String(_('heroRemoved'))], {'value': AppConfig.votesLimit}).subscribe((texts) => {
      const config: any = new MatSnackBarConfig();
      config.duration = AppConfig.snackBarDuration;
      this.snackBar.open(texts[name], 'OK', config);
    });
  }

  private PopulateHeros() {
    const thor = new Hero();
    thor.id = 'o0OFH4ddtfekOwK3ZKds';
    thor.name = 'Thor';
    thor.alterEgo = 'Donald Blake';
    // tslint:disable-next-line:max-line-length
    thor.avatarUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fo0OFH4ddtfekOwK3ZKds.jpg?alt=media&token=7cdac0a0-ac21-4203-943e-1cabe0c71f4c';
    // tslint:disable-next-line:max-line-length
    thor.avatarThumbnailUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fo0OFH4ddtfekOwK3ZKds-thumbnail.jpeg?alt=media&token=c39680fe-be8a-408f-89aa-bc4a2fd99ce7';
    thor.default = true;
    thor.likes = 2;
    const wonderWoman = new Hero();
    wonderWoman.id = '1cFiPzbhKt1zVVThrb9EH';
    wonderWoman.name = 'Wonder woman';
    wonderWoman.alterEgo = 'Diana Prince';
    // tslint:disable-next-line:max-line-length
    wonderWoman.avatarUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fz6jX346az6e6QifVj1Yd.jpg?alt=media&token=3cbe10ed-590f-4ca6-b088-0f927d53730d';
    // tslint:disable-next-line:max-line-length
    wonderWoman.avatarThumbnailUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2Fz6jX346az6e6QifVj1Yd-thumbnail.jpg?alt=media&token=bbd1720c-9003-4119-bb72-c0bc03b6412c';
    wonderWoman.default = true;
    wonderWoman.likes = 22;
    const spiderman = new Hero();
    spiderman.id = 'xxxxhKt1zVVThrb9EH';
    spiderman.name = 'Spiderman';
    spiderman.alterEgo = 'Peter Parker';
    // tslint:disable-next-line:max-line-length
    spiderman.avatarUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FcFiPzbhKt1zVVThrb9EH.jpg?alt=media&token=35d1cdd9-f1f2-416b-90d4-6bcba2e72305';
    // tslint:disable-next-line:max-line-length
    spiderman.avatarThumbnailUrl = 'https://firebasestorage.googleapis.com/v0/b/ismaestro-angularexampleapp.appspot.com/o/heroes-images%2FcFiPzbhKt1zVVThrb9EH-thumbnail.jpg?alt=media&token=dbdcd583-1851-46ad-bd23-df68ca37467e';
    spiderman.default = false;
    spiderman.likes = 9;
    this._heros.push(thor, wonderWoman, spiderman);
  }
}
