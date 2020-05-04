import {HomePage} from './home-page';
import {AppConfig} from '../../../../src/app/configs/app.config';
import {browser} from 'protractor';

describe('Home page', function () {
  let page;

  beforeEach(() => {
    page = new HomePage();
  });

  it('home page should contains a number of heroes less or equal to limit', () => {
    HomePage.navigateTo();
    browser.driver.sleep(2000);
    expect<any>(HomePage.getNumberHeroes()).toBeLessThanOrEqual(AppConfig.topHeroesLimit);
  });
});
