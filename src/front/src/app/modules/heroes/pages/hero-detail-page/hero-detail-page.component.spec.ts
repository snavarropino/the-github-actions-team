import {TestBed} from '@angular/core/testing';
import {APP_BASE_HREF} from '@angular/common';
import {HeroesModule} from '../../heroes.module';
import {TestsModule} from '../../../../shared/modules/tests.module';
import {TranslateModule} from '@ngx-translate/core';
import {HeroService} from '../../shared/hero.service';
import {ActivatedRoute, convertToParamMap} from '@angular/router';
import {APP_CONFIG, AppConfig} from '../../../../configs/app.config';
import {HeroDetailPageComponent} from './hero-detail-page.component';

describe('HeroDetailPage', () => {
  let fixture;
  let component;
  let heroService;

  beforeEach((() => {
    TestBed.configureTestingModule({
      imports: [
        TestsModule,
        TranslateModule.forRoot(),
        HeroesModule
      ],
      providers: [
        {provide: APP_CONFIG, useValue: AppConfig},
        {provide: APP_BASE_HREF, useValue: '/'},
        {
          provide: ActivatedRoute,
          useValue: {
            snapshot: {
              paramMap: convertToParamMap({
                id: 'BzTvl77YsRTtdihH0jeh'
              })
            }
          }
        },
        HeroService
      ],
    }).compileComponents();

    fixture = TestBed.createComponent(HeroDetailPageComponent);
    fixture.detectChanges();
    component = fixture.debugElement.componentInstance;
    heroService = TestBed.get(HeroService);
  }));

  it('should create hero detail component', (() => {
    expect(component).toBeTruthy();
  }));
});
