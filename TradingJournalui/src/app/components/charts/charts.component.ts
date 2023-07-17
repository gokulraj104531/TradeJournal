import { AfterViewInit, Component, OnInit } from '@angular/core';
declare const TradingView:any;
@Component({
  selector: 'app-charts',
  templateUrl: './charts.component.html',
  styleUrls: ['./charts.component.css']
})


export class ChartsComponent  {
 

  // ngOninit(){
  //   new TradingView.widget(
  //     {
  //     "width": 980,
  //     "height": 610,
  //     "symbol": "NASDAQ:AAPL",
  //     "timezone": "Etc/UTC",
  //     "theme": "Light",
  //     "style": "1",
  //     "locale": "en",
  //     "toolbar_bg": "#f1f3f6",
  //     "enable_publishing": false,
  //     "withdateranges": true,
  //     "range": "ytd",
  //     "hide_side_toolbar": false,
  //     "allow_symbol_change": true,
  //     "show_popup_button": true,
  //     "popup_width": "1000",
  //     "popup_height": "650",
  //     "no_referral_id": true,
  //     "container_id": "tradingview_bac65"
  //   }
  //     );
  // }


}
