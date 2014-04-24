<?php

/**
 * Description of ProductTest
 *
 * @author Hesham
 */
class MarketTest extends TestCase{
    
    public function testRetrieveProductPrice()
    {
        //load the market home
        $market = new Market();
        
        $market = Market::find(1);
        
        $product = $market->findProduct(array("barcode" => "123"));
        
        $price = $product->price;
        
        $this->assertEquals(6.75, $price);
    }
    
    public function testRetrieveProductIsNull()
    {
        //load the market home
        $market = new Market();
        
        $market = Market::find(1);
        
        $product = $market->findProduct(array("barcode" => "36541831"));
        
        $this->assertNull($product);
    }
    
    public function testRetrieveMarketNotNull()
    {
        $market = Market::find(1);
        
        $this->assertNotNull($market);
    }
    
    public function testDeleteProduct()
    {
        $market = Market::find(1);
        
        //create product to this market
        $product = new Product();
        $product->name = "Delete Me";
        $product->barcode = "64656464";
        $product->price = 7.25;
        $product->category
        
        $this->assertTrue($market->deleteProduct(11));
    }
    
}
