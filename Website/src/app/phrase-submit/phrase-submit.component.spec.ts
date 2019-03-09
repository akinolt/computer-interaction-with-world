import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhraseSubmitComponent } from './phrase-submit.component';

describe('PhraseSubmitComponent', () => {
  let component: PhraseSubmitComponent;
  let fixture: ComponentFixture<PhraseSubmitComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhraseSubmitComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhraseSubmitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
