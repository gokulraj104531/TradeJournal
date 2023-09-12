import { Component, NgZoneOptions, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Journal } from 'src/models/Journal';
import { HttpservicesService } from 'src/services/httpservices.service';
import * as FileSaver from 'file-saver';


@Component({
  selector: 'app-viewjournal',
  templateUrl: './viewjournal.component.html',
  styleUrls: ['./viewjournal.component.css'],
})
export class ViewjournalComponent implements OnInit {
  trade: any;
  nameid: any;
  EditId: any;
  tradearray: Journal[] = [];
  constructor(
    private tradeservice: HttpservicesService,
    private router: Router
  ) {
    this.nameid = sessionStorage.getItem('UserName');
  }
  ngOnInit(): void {
    this.getTrades();
  }

  getTrades(){
    this.tradeservice.GetTrade(this.nameid).subscribe((data) => {
      this.trade = data;
    });
  }

  DeleteTrade(journalId:number){
    this.tradeservice.DeleteTrade(journalId).subscribe(response=>{
      this.getTrades();
    });
  }

  
  generatePDF(name: string) {
    this.tradeservice.GeneratePdf(name).subscribe(
      (data: Blob) => {
        const blob = new Blob([data], { type: 'application/pdf' });
        FileSaver.saveAs(blob, 'Trading_Journal_' + name + '.pdf');
      },
      (error) => {
        console.error('Error generating PDF:', error);
      }
    );
  }


}
