import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';
import { CategoryFirst, ICategoryFirst } from '../category-first/categoryFirst';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-categpry-home',
  templateUrl: './categpry-home.component.html',
  styleUrls: ['./categpry-home.component.scss']
})
export class CategpryHomeComponent implements OnInit {
  categoryFirst: any = CategoryFirst;

  constructor(private categoryService: CategoryService) { }

  ngOnInit(): void {
    this.categoryService.categoryFirst$.subscribe((res: any) => {
      var firstJson = JSON.stringify(res);
      this.categoryFirst = JSON.parse(firstJson);
    });
  }

}
