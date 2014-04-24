<?php

Route::get('/', function()
{
	return View::make('hello');
});


Route::get("/products/retrieve", array(
    "as" => "products-retrieve",
    "uses" => "ProductController@retrieve"
    
));

Route::get("/products/create", array(
    "as" => "products-create",
    "uses" => "ProductController@formCreate"
    
));

Route::post("/products/create", array(
    "as" => "products-create-post",
    "uses" => "ProductController@create"
    
));

Route::get("/products/delete", array(
    "as" => "products-delete",
    "uses" => "ProductController@delete"
    
));

Route::post("/products/delete", array(
    "as" => "products-delete-post",
    "uses" => "ProductController@delete"
    
));

Route::get("/products/edit", array(
    "as" => "products-edit",
    "uses" => "ProductController@edit"
    
));

Route::post("/products/edit", array(
    "as" => "products-edit-post",
    "uses" => "ProductController@edit"
    
));

Route::get("/categories/retrieve", array(
    "as" => "categories-retrieve",
    "uses" => "MarketController@retrieveCategories"
));

Route::get("/markets/retrieve", array(
    "as" => "markets-retrieve",
    "uses" => "MarketController@retrieve"
));

