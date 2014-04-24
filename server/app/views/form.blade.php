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
            <form action="{{URL::route('products-create-post')}}" method="post">
                <p>
                    <label>
                        Name: 
                        <input type="text" name="name" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Bar Code: 
                        <input type="text" name="barcode" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Price: 
                        <input type="text" name="price" />
                    </label>
                </p>
                
                <p>
                    <label>
                        Category: 
                        <select name="category_id">
                            @foreach(Category::all() as $category)
                            <option value="{{$category->id}}">{{$category->name}}</option>
                            @endforeach
                        </select>
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
                
                <input type="submit" />
            </form>
        </div>
    </body>
</html>
