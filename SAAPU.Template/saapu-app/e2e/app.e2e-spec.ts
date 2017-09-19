import { SaapuAppPage } from './app.po';

describe('saapu-app App', () => {
  let page: SaapuAppPage;

  beforeEach(() => {
    page = new SaapuAppPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
