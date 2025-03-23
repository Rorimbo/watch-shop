import { Component, Input } from '@angular/core';
import { Link } from '../../types/Link';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {
  @Input('total') total: number = 0;

  links: Link[] = [
    { id: 0, name: 'Brands', url: '/brands' },
    { id: 1, name: 'News', url: '/news' },
    { id: 2, name: 'About', url: '/about' },
  ];
}
