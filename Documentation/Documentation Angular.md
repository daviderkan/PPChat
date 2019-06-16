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

La config se trouve dans le fichier `src/app/app.module.ts`

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

