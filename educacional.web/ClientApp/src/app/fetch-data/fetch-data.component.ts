import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public forecasts: Report[];

  constructor(http: HttpClient, @Inject('http://localhost:55571/api/Report/') baseUrl: string) {
    http.get<Report[]>(baseUrl + 'report').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}

interface Report {
  Student: string;  
}
