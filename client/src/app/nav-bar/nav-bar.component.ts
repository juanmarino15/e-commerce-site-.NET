import { Component } from '@angular/core';
// import { AccountService } from 'src/app/account/account.service';
// import { BasketService } from 'src/app/basket/basket.service';
// import { BasketItem } from 'src/app/shared/models/basket';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent {
  constructor() // public accountService: AccountService // public basketService: BasketService,
  {}

  getCount(items: any[]) {
    // return items.reduce((sum, item) => sum + item.quantity, 0);
  }
}
