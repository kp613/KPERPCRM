import { Component, OnInit } from '@angular/core';
import { CategoryFirst } from './category-first/categoryFirst';

@Component({
  selector: 'app-category',
  templateUrl: './category.component.html',
  styleUrls: ['./category.component.scss']
})
export class CategoryComponent implements OnInit {
  categoryFirst: CategoryFirst;

  constructor() { }

  ngOnInit(): void {
  }

}
