import { MyAppAngularPage } from './app.po';

describe('my-app-angular App', () => {
  let page: MyAppAngularPage;

  beforeEach(() => {
    page = new MyAppAngularPage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
