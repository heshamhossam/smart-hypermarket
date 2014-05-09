package com.hci.smarthypermarket;

import java.util.ArrayList;
import java.util.List;

import android.R.anim;
import android.app.Activity;
import android.app.ListActivity;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ListAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.TextView;

public class BrowseActivity extends Activity {
	//String [] products={"eslam","loma","hosam","hesham"};
	List<Product> products;
	Market market;
	private ListView listView1;
	
	
	
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		
		// TODO Auto-generated method stub
	super.onCreate(savedInstanceState);
	
    setContentView(R.layout.productslist);
    
    Product productss[] = new Product[]{
			new Product("123","eslam","3445",4,"long","djdj"),
			new Product("124","es5atm","3445",4,"long","djdj"),
			new Product("125","es5amt","3445",4,"long","djdj"),
			
			
	};
    try{
  
    Log.d("mees",Integer.toString(productss.length));
	ProductAdapter adapter = new ProductAdapter(this, R.layout.productitem,productss);
	listView1 = (ListView) findViewById(R.id.listView1);
	View header = (View)getLayoutInflater().inflate(R.layout.productsheader, null);
	listView1.addHeaderView(header);
	listView1.setAdapter(adapter);
	 products =  LauncherActivity.market.getproducts();
    }
    catch(Exception e)
    {
    	
    }
	}
	
	public BrowseActivity() {
		
		
	}
	
	public void showProducts(List<Category> categories)
	{
		
		
	}
	

	
}


