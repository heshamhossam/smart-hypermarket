<!DOCTYPE html>
<!--
To change this license header, choose License Headers in Project Properties.
To change this template file, choose Tools | Templates
and open the template in the editor.
-->
<html>
    <head>
        <title>TODO supply a title</title>
        <meta charset="UTF-8">
        <meta name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    <body>
        <div>
            <form action="{{URL::route('offers-create-post')}}" method="post">
                
                 <p>
                    <label>
                        Name: 
                        <input type="text" name="name" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Teaser: 
                        <input type="text" name="teaser" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Price: 
                        <input type="number" name="price" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Market: 
                        <select name="market_id">
                            @foreach(Market::all() as $market)
                            <option value="{{$market->id}}">{{$market->name}}</option>
                            @endforeach
                        </select>
                    </label>
                </p>
                
                <p>
                    <label>
                        Product 1: 
                        <select name="product_ids[]" multiple="true">
                            @foreach(Product::all() as $product)
                            <option value="{{$product->id}}">{{$product->name}}</option>
                            @endforeach
                        </select>
                    </label>
                </p>
                
                <p>
                    <label>
                        Product Quantities: 
                        <select name="product_quantities[]" multiple="true">
                            <option value="1">Quantity 1</option>
                            <option value="2">Quantity 2</option>
                            <option value="3">Quantity 3</option>
                        </select>
                    </label>
                </p>
                
                
                
                
                
                
                
                <input type="submit" />
            </form>
        </div>
    </body>
</html>
