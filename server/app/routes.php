<?php

Route::get('/', function()
{
	return View::make('hello');
});


Route::get("/products/retrieve", array(
    "as" => "products-retrieve",
    "uses" => "ServiceController@retrieveProduct"
    
));

Route::get("/products/create", array(
    "as" => "products-create",
    "uses" => "ServiceController@getForm"
    
));

Route::post("/products/create", array(
    "as" => "products-create-post",
    "uses" => "ServiceController@createProduct"
    
));

Route::get("/categories/retrieve", array(
    "as" => "categories-retrieve",
    "uses" => "ServiceController@retrieveCategories"
));

Route::get("/markets/retrieve", array(
    "as" => "markets-retrieve",
    "uses" => "ServiceController@retrieveMarket"
));

