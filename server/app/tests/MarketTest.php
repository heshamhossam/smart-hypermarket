<?php

/**
 * Description of ProductTest
 *
 * @author Hesham
 */
class MarketTest extends TestCase{
    
    public function testRetrieveProductPrice()
    {
        //create product
        $product = new Product();
        $product->name = "test add product";
        $product->barcode = "387165413";
        
        $product->save();
        
        $market = Market::all()->first();
        
        //find category to attach it to
        $category = Category::all()->first();
        
        $added = $market->addProduct($product, $category, 5);
        
        $product = $market->findProduct(array("id" => $product->id));
        
        $price = $product->price;
        
        $this->assertEquals(5, $price);
    }
    
    public function testRetrieveProductIsNull()
    {
        //load the market home
        $market = new Market();
        
        $market = Market::find(1);
        
        $product = $market->findProduct(array("barcode" => "365646541831"));
        
        $this->assertNull($product);
    }
    
    public function testRetrieveMarketNotNull()
    {
        $market = Market::find(1);
        
        $this->assertNotNull($market);
    }
    
    public function testAddProduct()
    {
        $market = Market::all()->first();
        
        //create product
        $product = new Product();
        $product->name = "add me plz";
        $product->barcode = "387165413";
        
        $product->save();
        
        //find category to attach it to
        $category = Category::all()->first();
        
        $added = $market->addProduct($product, $category, 7.223);
        
        $this->assertTrue($added);
        
    }
    
    public function testDeleteProduct()
    {
        $market = Market::find(1);
        
        //create product
        $product = new Product();
        $product->name = "delete me plz";
        $product->barcode = "468541541";
        
        $product->save();
        
        //find category to attach it to
        $category = Category::all()->first();
        
        $market->addProduct($product, $category, 7.223);
        
        //delete the product
        $deleted = $market->deleteProduct($product);
        
        $this->assertTrue($deleted);
    }
    
    public function testEditProduct()
    {
        $market = Market::find(1);
        
        $product = $market->products->first();
        
        $product->name = "edit product";
        
        $product->update();
        
        $edited = $market->editProduct($product, array("price" => 152.36));
        
        $editedProduct = $market->findProduct(array("id" => $product->id));
        
        $this->assertEquals("edit product", $editedProduct->name);
        
    }
    
}
