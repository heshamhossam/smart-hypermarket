<?php

Route::get('/', function()
{
	return View::make('hello');
});


Route::get("/products/retrieve", array(
    "as" => "products-retrieve",
    "uses" => "MarketController@retrieveProduct"
    
));

//it get products array 
Route::get("/products/get", array(
    "as" => "categories-retrieve",
    "uses" => "MarketController@retrieveCategoriesOnly"
));

Route::get("/products/get", array(
    "as" => "products-get",
    "uses" => "MarketController@getProducts"
    
));

Route::post("/products/create", array(
    "as" => "products-create-post",
    "uses" => "MarketController@createProduct"
    
));

Route::get("/products/create", function() {
    return View::make("form");
});

Route::get("/products/delete", array(
    "as" => "products-delete",
    "uses" => "MarketController@deleteProduct"
    
));

Route::post("/products/delete", array(
    "as" => "products-delete-post",
    "uses" => "MarketController@deleteProduct"
    
));

Route::get("/products/edit", array(
    "as" => "products-edit",
    "uses" => "MarketController@editProduct"
    
));

Route::post("/products/edit", array(
    "as" => "products-edit-post",
    "uses" => "ProductController@edit"
    
));

Route::get("/categories/retrieve", array(
    "as" => "categories-retrieve",
    "uses" => "MarketController@retrieveCategories"
));

//it get categories without aggregation with products
Route::get("/categories/get", array(
    "as" => "categories-get",
    "uses" => "MarketController@retrieveCategoriesOnly"
));



Route::get("/categories/get", array(
    "as" => "categories-retrieve",
    "uses" => "MarketController@retrieveCategoriesOnly"
));

Route::get("/markets/retrieve", array(
    "as" => "markets-retrieve",
    "uses" => "MarketController@retrieve"
));

Route::get("/orders/retrieve", array(
    "as" => "orders-retrieve",
    "uses" => "MarketController@getOrders"
));

Route::post("/orders/create", array(
    "as" => "orders-create-post",
    "uses" => "ShopperController@createOrder"
));

Route::get("/orders/edit", array(
    "as" => "orders-edit-post",
    "uses" => "MarketController@editOrder"
));

Route::get("/orders/create", function()
{
    return View::make("createOrder");
});

