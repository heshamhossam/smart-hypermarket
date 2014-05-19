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
            <form action="{{URL::route('orders-create-post')}}" method="post">
                <p>
                    <label>
                        First Name: 
                        <input type="text" name="first_name" />
                    </label>
                    
                    <label>
                        Last Name: 
                        <input type="text" name="last_name" />
                    </label>
                </p>
                
                <p>
                    <label>
                        mobile: 
                        <input type="tel" name="mobile" />
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
                        <select name="product_ids[]">
                            @foreach(Product::all() as $product)
                            <option value="{{$product->id}}">{{$product->name}}</option>
                            @endforeach
                        </select>
                    </label>
                    
                    <label>
                        Quantity: 
                        <input type="number" name="product_quantities[]" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Product 2: 
                        <select name="product_ids[]">
                            @foreach(Product::all() as $product)
                            <option value="{{$product->id}}">{{$product->name}}</option>
                            @endforeach
                        </select>
                    </label>
                    
                    <label>
                        Quantity: 
                        <input type="number" name="product_quantities[]" />
                    </label>
                </p>
                
                
                
                
                
                <input type="submit" />
            </form>
        </div>
    </body>
</html>
