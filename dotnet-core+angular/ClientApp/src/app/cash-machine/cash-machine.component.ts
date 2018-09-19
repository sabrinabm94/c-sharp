import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-cash-machine',
  templateUrl: './cash-machine.component.html'
})

export class CashMachineComponent {
  balance = 100;

  getAction(action: string, accountId: number, inputValue: number) {
    console.log(action);
    console.log(accountId);
    console.log(inputValue);
    this.balance = this.balance - inputValue;
  }

  //pegar as informações cashMachineController
  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.post<WeatherForecast[]>(baseUrl + 'api/SampleData/WeatherForecasts').subscribe(result => {
      this.forecasts = result;
    }, error => console.error(error));
  }
}
