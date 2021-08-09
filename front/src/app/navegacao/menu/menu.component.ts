import { Component } from '@angular/core';
import { Nav } from './nav.menu';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html'
})
export class MenuComponent {

  nav: Nav[] = [    
    {
      route: '/cadastro',
      nome: 'Cadastro',
      exact: true,
      admin: false
    },                  
  ];       

}
