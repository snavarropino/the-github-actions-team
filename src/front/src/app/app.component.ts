import {Component, OnInit} from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import {Meta, Title} from '@angular/platform-browser';
import {NavigationEnd, Router} from '@angular/router';
import {MatSnackBar} from '@angular/material';
import {_} from '@biesbjerg/ngx-translate-extract/dist/utils/utils';
import {AppConfig} from './configs/app.config';
import {LocalStorage} from 'ngx-store';
import {UtilsHelperService} from './core/services/utils-helper.service';
import { AppSettingsProvider } from './core/services/settings-provider.service';

declare const require;
declare const Modernizr;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})

export class AppComponent implements OnInit {

  @LocalStorage() language = 'en';
  isOnline: boolean;

  constructor(private translateService: TranslateService,
              private title: Title,
              private meta: Meta,
              private snackBar: MatSnackBar,
              private router: Router,
              private _settingsProvider: AppSettingsProvider ) {
    this.isOnline = navigator.onLine;
  }

  ngOnInit() {
    this.translateService.setDefaultLang('en');
    this.translateService.use(this.language);
    this._settingsProvider.load()
    .then( settings => {
      console.log('Settings loaded');
  });

    // With this we load the default language in the main bundle (cache busting)
    this.translateService.setTranslation('en', require('../assets/i18n/en.json'));

    this.title.setTitle('Angular Example App');

    this.onEvents();
    this.checkBrowser();
  }

  onEvents() {
    this.router.events.subscribe((event: any) => {
      if (event instanceof NavigationEnd) {
        switch (event.urlAfterRedirects) {
          case '/':
            this.meta.updateTag({
              name: 'description',
              content: 'Angular Example app with Angular CLI, Angular Material and more'
            });
            break;
          case '/' + AppConfig.routes.heroes:
            this.title.setTitle('Heroes list');
            this.meta.updateTag({
              name: 'description',
              content: 'List of super-heroes'
            });
            break;
        }
      }
    });
  }

  checkBrowser() {
    if (UtilsHelperService.isBrowserValid()) {
      this.checkBrowserFeatures();
    } else {
      this.translateService.get([String(_('changeBrowser'))]).subscribe((texts) => {
        this.snackBar.open(texts['changeBrowser'], 'OK');
      });
    }
  }

  checkBrowserFeatures() {
    let supported = true;
    for (const feature in Modernizr) {
      if (Modernizr.hasOwnProperty(feature) &&
        typeof Modernizr[feature] === 'boolean' && Modernizr[feature] === false) {
        supported = false;
        break;
      }
    }

    if (!supported) {
      this.translateService.get([String(_('updateBrowser'))]).subscribe((texts) => {
        this.snackBar.open(texts['updateBrowser'], 'OK');
      });
    }

    return supported;
  }
}
