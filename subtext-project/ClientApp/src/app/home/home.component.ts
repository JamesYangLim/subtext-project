import { Component, Inject, ViewEncapsulation } from '@angular/core';
import { FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { HighlightTag } from 'angular-text-input-highlight';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class HomeComponent {

  text: string = '';
  subtext = new FormControl('');
  positions = new FormControl('');
  http: HttpClient;
  baseUrl: string;
  tags: HighlightTag[] = [];

  constructor(
    http: HttpClient,
    @Inject('BASE_URL') baseUrl: string
  ) {
    this.http = http;
    this.baseUrl = baseUrl;
  }

  onSubmit() {
    let body = { text: this.text, subtext: this.subtext.value };
    this.http.post<number[]>(this.baseUrl + 'subtext', body).subscribe(result => {
      this.addTags(result);
      this.positions.setValue('Found subtexts positions at ' + result);
    }, error => console.error(error));
  }

  clearTags() {
    this.tags = [];
  }

  addTags(indices: number[]) {
    this.clearTags();
    for (let i = 0; i < indices.length; ++i) {
      this.tags.push({
        indices: {
          start: indices[i],
          end: indices[i] + this.subtext.value.length
        }
      });
    }
  }
}
