import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { PhraseToSay } from './phrase-to-say';
import { MessageService } from './message.service';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({ providedIn: 'root' })
export class PhrasesService {

  private phrasesUrl = 'api/phrases/queue';

  constructor(
    private http: HttpClient,
    private messageService: MessageService) { }

  //////// Save methods //////////

  /** POST: add a new phraseToSay to the server */
  submitPhrase (phraseToSay: PhraseToSay): Observable<PhraseToSay> {
    return this.http.put<PhraseToSay>(this.phrasesUrl, phraseToSay, httpOptions).pipe(
      tap((newPhraseToSay: PhraseToSay) => this.log(`added phraseToSay w/ id=${newPhraseToSay.phrase}`)),
      catchError(this.handleError<PhraseToSay>('addPhraseToSay'))
    );
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }

  /** Log a PhrasesService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`PhrasesService: ${message}`);
  }
}
