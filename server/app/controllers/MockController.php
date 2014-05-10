<?php


/**
 * Description of MockController
 *
 * @author Hesham
 */
class MockController extends BaseController {
    
    public function getTrue()
    {
        $response = array("success" => true);
        return Response::json($response);
    }
    
    public function getFalse()
    {
        $response = array("success" => false);
        return Response::json($response);
    }
    
    public function retrieveCategories()
    {
        $response = array(
            array(
                "id" => 1,
                "name" => "Test",
                "created_at" => "2014-04-01 00:00:00",
                "updated_at" => "2014-04-02 00:00:00",
                "category_id" => null,
                "products" => array(
                    array(
                        "id" => "2",
                        "name" => "Lemon",
                        "barcode" => "3939",
                        "description" => "this is test description",
                        "weight" => "256",
                        "created_at" => "2014-04-25 00:15:13",
                        "updated_at" => "2014-05-03 20:19:56",
                        "price" => 292
                    )
                )
            )
        );
        
        return Response::json($response);
    }
}
