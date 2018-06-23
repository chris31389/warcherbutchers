import { TestBed, inject } from '@angular/core/testing';

import { StoreSnippetService } from './store-snippet.service';

describe('StoreSnippetService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [StoreSnippetService]
    });
  });

  it('should be created', inject([StoreSnippetService], (service: StoreSnippetService) => {
    expect(service).toBeTruthy();
  }));
});
