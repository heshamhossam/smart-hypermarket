<?php

/**
 * Description of ProductController
 *
 * @author Hesham
 */
class ProductController extends BaseController {
    
    //retrieve a product from database
    
    public function retrieve()
    {
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
    
    //delete product from database
    public function delete()
    {
        //get the market id if exist
        $market_id = Input::has("market_id")? Input::get("market_id") : false;
        
        $market = Market::find($market_id);

        
        //get the product id
        $product_id = Input::has("id")? Input::get("id") : false;
        
        
        $deleted = null;
        
        if ($market && $product_id)
            $deleted = $market->deleteProduct($product_id);
        else if ($product_id)
            $deleted = Product::deleteMe($product_id);
        
        if (!$deleted)
            return "Delete Faaaails";
        
        
    }
    
    public function formCreate()
    {
        return View::make("form");
    }
    
    //create new product
    public function create()
    {   
        $product = new Product();
        
        $product->name = Input::get("name");
        $product->barcode = Input::get("barcode");
        
        $product->save();
        
        //save the product in the category
        DB::table('category_product')->insert(
            array('category_id' => Input::get("category_id"), 'product_id' => $product->id)
        );
        
        //save the product in the market
        DB::table('market_product')->insert(
            array('market_id' => Input::get("market_id"), 'product_id' => $product->id, "price" => Input::get("price"))
        );
        
        if ($product)
        {
            $p = $product->toArray();
            
            $response = array(
                "success" => 1,
                "product" => $p
            );
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

    
    public function edit()
    {
        if (!Input::has("id"))
            return "Please Enter Valid input ID to edit";
        
        $product_id = Input::get("id");
        
        $product = Product::find($product_id);
        $product->name = Input::get("name");
        $product->barcode = Input::get("barcode");
        $product->save();
        
        DB::table('market_product')
            ->where('product_id', $product_id)
            ->where('market_id', Input::get("market_id"))
            ->update(array('price' => Input::get("price")));
        
    }
}