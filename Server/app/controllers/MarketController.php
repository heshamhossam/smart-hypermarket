<?php

/**
 * Description of MarketController
 *
 * @author Hesham
 */
class MarketController extends BaseController {
    
    //retrieve a product from database
    
    public function retrieveProduct()
    {
//        $review = Review::find(1);
//        //$review->user = $review->user();
//        return $review->user;
        //@barcode: string contains bar code of the product to be retrieved
        $key = "barcode";
        $value = 0;
        $market_id = Input::get("market_id");
        
        if (Input::has("barcode"))
            $key = "barcode";
        else if (Input::has("id"))
            $key = "id";
        
        $value = Input::get($key);
        
        $market = Market::find($market_id);
        $product = NULL;
        
        if ($market)
            $product = $market->findProduct(array("$key" => $value));
        
        
        
        if ($product)
        {
            $response = array(
                "success" => 1,
                "product" => $product->toArray()
            );
        }
        else
        {
            $response = array(
                "success" => 0,
                "message" => "No Product with the given $key $value"
            );
        }
        
        return Response::json($response);
        
        
    }
    
    //get products by market id and category id
    public function getProducts()
    {
        $marketId = Input::has("market_id")? Input::get("market_id") : null;
        $categoryId = Input::has("category_id")? Input::get("category_id") : null;
        
        $market = Market::find($marketId);
        $category = Category::find($categoryId);
            
        if ($market && $category)
        {
            $products = $category->getProducts($market);
            
            return Response::json(array("products" => $products));
        }
    }
    
    //delete product from database
    public function deleteProduct()
    {
        //get the market id if exist
        $market_id = Input::has("market_id")? Input::get("market_id") : false;
        
        $market = Market::find($market_id);

        
        //get the product id
        $product_id = Input::has("id")? Input::get("id") : false;
        
        $product = Product::find($product_id);
        
        $deleted = null;
        
        if ($market && $product)
            $deleted = $market->deleteProduct($product);
        else if ($product_id)
            $deleted = Product::deleteMe($product_id);
        
        if (!$deleted)
            return "Delete Faaaails";
        
        
    }
    
    //create new product
    public function createProduct()
    {   
        //create the product
        $product = new Product();
        
        $product->name = Input::get("name");
        $product->barcode = Input::get("barcode");
        $product->weight = Input::get("weight");
        $product->description = Input::get("description");
        
        $product->save();
        
        $market = Market::find(Input::get("market_id"));
        $category = Category::find(Input::get("category_id"));
        
        
        if ($market && $category)
            $created = $market->addProduct($product, $category, Input::get("price"));
        
        
        if ($created)
        {
            $product = $market->findProduct(array("id" => $product->id));
            return $product;
        }
        else
        {
            $response = array(
                "success" => 0,
                "message" => "No Product with the given created"
            );
        }
        
        return Response::json($response);
        
    }
    
    public function retrieve()
    {
        $latitude = Input::has("latitude") ? Input::get("latitude") : 0;
        $longitude = Input::has("longitude") ? Input::get("longitude") : 0;
        
        //approximate the location
        $latitude = round($latitude * 10000) / 10000;
        $longitude = round($longitude * 10000) / 10000;
        
        
        
//        $locations = Location::where("latitude", "=", $latitude)
//                    ->where("longitude", "=", $longitude);
        
        $locations = Location::all();
        
        
        
        if ($locations->count())
        {
            $location = $locations->first();
            
            $market = Market::where("location_id", "=", $location->id)->first()->toArray();
            
            
            $response = array(
                "success" => 1,
                "market" => $market
            );
        }
        else
        {
            $response = array(
                "success" => 0,
                "message" => "No Market with the given location (latitude = $latitude, longitude = $longitude)"
            );
        }
        
        return Response::json($response);
        
        
    }
    
    //retrieve all categories from database
    public function retrieveCategories()
    {   
        if (Input::has("market_id"))
            $marketId = Input::get("market_id");
        else
            return Response::json(array("success" => 0, "message" => "No Market with the market id"));
        
        $market = Market::find($marketId);
        
        //response json 
        $response = array();
        
        
        
        foreach ($market->categories as $category)
        {   
            $productIndex = 0;
            foreach ($category->products as $product) {
                $products[$productIndex] = $market->findProduct(array("id" => $product->id));
                $product->price = $products[$productIndex]->price;
                $productIndex++;
            }
        }
        return $market->categories;
        
    }
    
    
    public function retrieveCategoriesOnly()
    {
        $marketId = Input::has("market_id") ? Input::get("market_id") : null;
        
        if ($marketId)
        {
            $market = Market::find($marketId);
            
            $categories = $market->categories;
            foreach ($categories as $category) {
                $category->bluetooth = $category->bluetooth;
            }
            
            return Response::json(array("categories" => $categories->toArray()));
        }
        
    }
    
    public function editProduct()
    {
        if (!Input::has("id"))
            return "Please Enter Valid input ID to edit";
        
        $product_id = Input::get("id");
        
        $product = Product::find($product_id);
        $product->name = Input::has("name")? Input::get("name") : $product->name;
        $product->barcode = Input::has("barcode")? Input::get("barcode") : $product->barcode;
        $product->description = Input::has("description")? Input::get("description") : $product->description;
        $product->weight = Input::has("weight")? Input::get("weight") : $product->weight;
        $product->save();
        
        $market = Market::find(Input::get("market_id"));
        
        if ($market)
        {
            $market->editProduct($product, array("price" => Input::get("price")));
        }
        
    }
    
    public function getOrders()
    {
        $marketId = Input::has("market_id") ? Input::get("market_id") : null;
        $ordersFilter = Input::has("filter") ? Input::get("filter") : null;
        
        $market = Market::find($marketId);
        
        if ($market && $ordersFilter)
        {
            $orders = $market->getOrders($ordersFilter);
            
            return Response::json($orders);
        }
    }
    
    public function editOrder()
    {
        $orderId = Input::has("order_id") ? Input::get("order_id") : null;
        
        $order = Order::find($orderId);
        
        if ($order)
        {
            $order->state = Input::has("state") ? Input::get("state") : $order->state;
            $order->update();
        }
    }
    
    
    
    
    public function changeInputsToArray($key)
    {
        $values = array();
        $i = 0;
        while (Input::has($key . $i))
        {
            $values[] = Input::get($key . $i);
            $i++;
        }
        
        return $values;
    }
    
    
    
    
}
