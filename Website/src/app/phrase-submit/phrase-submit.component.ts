import { Component, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';
import { PhrasesService } from '../phrases.service';
import { PhraseToSay } from '../phrase-to-say'
import { Gender } from '../gender'

@Component({
  selector: 'app-phrase-submit',
  templateUrl: './phrase-submit.component.html',
  styleUrls: ['./phrase-submit.component.css']
})
export class PhraseSubmitComponent {
  name = new FormControl('');
  
  constructor(private phrasesService: PhrasesService) { }

  sendPhrase() {
    let gender = new Gender();
    gender.value = "Male";
    let phraseToSay = new PhraseToSay();
    phraseToSay.phrase = this.name.value;
    phraseToSay.language = "en-US";
    phraseToSay.gender = gender;
    this.phrasesService.submitPhrase(phraseToSay)
      .subscribe(phrases => { });
  }
}
