import {NgModule} from '@angular/core';
import {MaterialModule} from './modules/material.module';
import {TranslateModule} from '@ngx-translate/core';
import {FlexLayoutModule} from '@angular/flex-layout';
import {CommonModule} from '@angular/common';
import {SpinnerComponent} from './components/spinner/spinner.component';
import {FooterComponent} from './components/footer/footer.component';
import {SearchBarComponent} from './components/search-bar/search-bar.component';
import {HeaderComponent} from './components/header/header.component';
import {ReactiveFormsModule} from '@angular/forms';
import {RouterModule} from '@angular/router';
import {HomePageComponent} from './pages/home-page/home-page.component';
import {Error404PageComponent} from './pages/error404-page/error404-page.component';
import {HeroCardComponent} from './components/hero-card/hero-card.component';
import {NgxExampleLibraryModule} from '@ismaestro/ngx-example-library';
import {WebStorageModule} from 'ngx-store';
import {HeroLoadingComponent} from './components/hero-loading/hero-loading.component';
import {NgxScrollToFirstInvalidModule} from '@ismaestro/ngx-scroll-to-first-invalid';
import {LoadingPlaceholderComponent} from './components/loading-placeholder/loading-placeholder.component';

@NgModule({
  imports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    TranslateModule.forChild(),
    ReactiveFormsModule,
    RouterModule,
    NgxExampleLibraryModule,
    WebStorageModule,
    NgxScrollToFirstInvalidModule
  ],
  declarations: [
    HomePageComponent,
    Error404PageComponent,
    HeaderComponent,
    SearchBarComponent,
    FooterComponent,
    SpinnerComponent,
    HeroCardComponent,
    HeroLoadingComponent,
    LoadingPlaceholderComponent
  ],
  exports: [
    CommonModule,
    MaterialModule,
    FlexLayoutModule,
    TranslateModule,
    NgxExampleLibraryModule,
    WebStorageModule,
    HeaderComponent,
    SearchBarComponent,
    FooterComponent,
    SpinnerComponent,
    HeroCardComponent,
    HeroLoadingComponent,
    NgxScrollToFirstInvalidModule,
    LoadingPlaceholderComponent
  ]
})

export class SharedModule {
}
