import { HogRoastModule } from './hog-roast.module';

describe('HogRoastModule', () => {
  let hogRoastModule: HogRoastModule;

  beforeEach(() => {
    hogRoastModule = new HogRoastModule();
  });

  it('should create an instance', () => {
    expect(hogRoastModule).toBeTruthy();
  });
});
