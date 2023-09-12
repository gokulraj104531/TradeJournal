import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserRegisteration } from 'src/models/UserRegisteration';
import { Journal } from 'src/models/Journal';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';
import { ProfitorLoss } from 'src/models/ProfitorLoss';
@Injectable({
  providedIn: 'root',
})
export class HttpservicesService {
  name: any;
  constructor(private httpclient: HttpClient) {}

  baseurl = 'https://localhost:7012/';

  //Signup page
  AddUser(user: UserRegisteration): Observable<UserRegisteration> {
    return this.httpclient.post<UserRegisteration>(
      this.baseurl + 'api/UserRegistration/AddUser',
      user
    );
  }

  //Login page
  Login(username: String, password: String): Observable<string> {
    return this.httpclient.get(
      this.baseurl + 'api/UserRegistration/Login/' + username + '/' + password,
      {
        responseType: 'text',
      }
    );
  }

  //Addtrade
  AddTrade(trade: Journal): Observable<Journal> {
    return this.httpclient.post<Journal>(
      this.baseurl + 'api/Journal/AddTrade',
      trade
    );
  }

  //edittrade
  EditTrade(trade: Journal): Observable<any> {
    return this.httpclient.put(this.baseurl + 'api/Journal/EditTrade', trade);
  }

  //deletetrade
  DeleteTrade(journalId: number): Observable<Journal> {
    return this.httpclient.delete<Journal>(
      this.baseurl + 'api/Journal/DeleteTrade/' + journalId
    );
  }

  //getjournalbyid
  GetJournalById(journalId: any): Observable<any> {
    return this.httpclient.get(
      this.baseurl + 'api/Journal/GetTradeDetailsByID/' + journalId
    );
  }

  //get trade details
  GetTrade(nameid: string) {
    return this.httpclient.get(
      this.baseurl + 'api/Journal/GetTradeDetails/' + nameid
    );
  }

  //get profit count
  GetProfitCount(name: string) {
    return this.httpclient.get(this.baseurl + 'api/Journal/Profit/' + name);
  }

  //tradecount
  GetTradeCount(name: string) {
    return this.httpclient.get(this.baseurl + 'api/Journal/TotalCount/' + name);
  }

  //profit percent
  ProfitPercent(name: string) {
    return this.httpclient.get(
      this.baseurl + 'api/Journal/ProfitPercent/' + name
    );
  }

  //linechart
  Linechart(name: string): Observable<ProfitorLoss[]> {
    return this.httpclient.get<ProfitorLoss[]>(
      this.baseurl + 'api/Journal/LineChart/' + name
    );
  }

  GeneratePdf(name: string): Observable<any> {
    return this.httpclient.get(
      this.baseurl + 'api/Journal/GeneratePdf/' + name,
      { responseType: 'blob' }
    );
  }
}
