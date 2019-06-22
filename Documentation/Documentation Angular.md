[TOC]



# Angular

## Component

### définition

Un composant est un bout de vue configurable grâce a 3 fichier :

- <component_name>.css
- <component_name>.html
- <component_name>.ts

Ils permettent de configurer le template, le style et le comportement du component.

### Template

#### Syntaxe

- `*ngFor`
- `*ngIf`
- Interpolation `{{ }}`
- Property binding `[ ]` 
- Event binding `( )`

#### Exemples 

**Exemple 1 :**

- contient un <p> affichable uniquement si `product.price > 700`
- le <button> exécute `notify.emit()`
- toute les variables sont dans le fichier `.ts` du component

```html
<p *ngIf="product.price > 700">
  <button (click)="notify.emit()">Notify Me</button>
</p>
```

**Exemple 2 :**

On parcourt ``products``, modifie le comportement de boutons et bind certaines propriétés, on rajoute des données grâce à l'interpolation.

On bind certaines propriétés et des évènements.

```html
<h2>Products</h2>

<div *ngFor="let product of products">

  <h3>
    <a [title]="product.name + ' details'">
      {{ product.name }}
    </a>
  </h3>

  <p *ngIf="product.description">
    Description: {{ product.description }}
  </p>

  <button (click)="share()">
    Share
  </button>

  <app-product-alerts [product]="product" (notify)="onNotify()"> 
  </app-product-alerts>

</div>
```

### Comportement

A compléter...

### Routing

Il y a moyen de binder certaines routes afin de naviguer de component en component

**Exemple**

#### Enregistrer une route

fichier `src/app/app.module.ts`

Si l'url est `products/:productId`, on affiche le component `ProductDetailsComponent`

Si l'url est inchangé, on affiche le component `ProductListComponent`

```typescript
@NgModule({
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: ProductListComponent },
      { path: 'products/:productId', component: ProductDetailsComponent },
    ])
  ],
```

Rajouter une directive `routerLink`

ici, l'url contient une partie fixe `/products` et une deuxième partie étant l'id du produit (`productId` est une variable local a la boucle for)

```html
<div *ngFor="let product of products; index as productId">

  <h3>
    <a [title]="product.name + ' details'" [routerLink]="['/products', productId]">
      {{ product.name }}
    </a>
  </h3>
<!-- . . . -->
</div>
```

#### Utiliser les infos de la route

1. importer `ActivatedRoute`
2. injecter `ActivatedRoute` dans le constructeur
3. dans la méthode `ngOnInit()`,  s'enregistrer au paramètres de la route et faire les modifications nécessaires. 

```typescript
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import { products } from '../products';

...

export class ProductDetailsComponent implements OnInit {
  product;

  constructor(
    private route: ActivatedRoute,
  ) { }
    
}

ngOnInit() {
  this.route.paramMap.subscribe(params => {
    this.product = products[+params.get('productId')];
  });
}
```

4. voila un exemple de template 

   

   ```html
   <h2>Product Details</h2>
   
   <div *ngIf="product">
     <h3>{{ product.name }}</h3>
     <h4>{{ product.price | currency }}</h4>
     <p>{{ product.description }}</p>
   
   </div>
   ```

   

