import { TestBed } from '@angular/core/testing';

import { EventsApiServiceService } from './events-api-service.service';

describe('EventsApiServiceService', () => {
  let service: EventsApiServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventsApiServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
