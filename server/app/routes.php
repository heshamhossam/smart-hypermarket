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


Route::get("/orders/create", array(
    "as" => "orders-create-post",
    "uses" => "ShopperController@createOrder"
));



Route::get("/orders/get", array(
    "as" => "orders-get",
    "uses" => "ShopperController@getOrder"
));

Route::get("/orders/edit", array(
    "as" => "orders-edit-post",
    "uses" => "MarketController@editOrder"
));

Route::get("/reviews/create", array(
    "as" => "reviews-create",
    "uses" => "ShopperController@createReview"
));

//Route::get("/offers/create", array(
//    "as" => "offers-create",
//    "uses" => "OfferController@getCreateOfferForm"
//));

Route::get("/offers/create", array(
    "as" => "offers-create",
    "uses" => "OfferController@create"
));

Route::post("/offers/create", array(
    "as" => "offers-create-post",
    "uses" => "OfferController@create"
));

Route::get("/offers/retrieve", array(
    "as" => "offers-retrieve",
    "uses" => "OfferController@retrieve"
));

Route::get("/offers/delete", array(
    "as" => "offers-delete",
    "uses" => "OfferController@delete"
));

Route::get("/offers/edit", array(
    "as" => "offers-edit",
    "uses" => "OfferController@edit"
));

//Route::get("/orders/create", function()
//{
//    return View::make("createOrder");
//});
Route::get("/mocks/true", array(
    "as" => "mocks-true",
    "uses" => "MockController@getTrue"
));

Route::get("/mocks/false", array(
    "as" => "mocks-false",
    "uses" => "MockController@getFalse"
));

Route::get("mocks/categories/retrieve", array(
    "as" => "mocks-categories-retrieve",
    "uses" => "MockController@retrieveCategories"
));