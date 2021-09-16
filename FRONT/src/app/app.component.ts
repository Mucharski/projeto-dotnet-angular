import { Component, OnInit } from '@angular/core';
import { Produto } from './models/produto';
import { ProdutoService } from './services/produto.service';

@Component({
  selector: 'app-root',
  templateUrl: "./app.component.html",
  styles: []
})
export class AppComponent implements OnInit {

  produtos: Produto[] = [];

  constructor(private service: ProdutoService) { }

  ngOnInit(): void {

    this.service.list().subscribe(produtos => {
      this.produtos = produtos;
      for (let produto of produtos) {
        console.log(produto);
      }
    })

  }

}
