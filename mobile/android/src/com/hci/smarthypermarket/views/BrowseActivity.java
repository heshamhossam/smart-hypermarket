package com.hci.smarthypermarket.views;

import java.util.HashMap;
import java.util.List;

import com.hci.smarthypermarket.R;
import com.hci.smarthypermarket.models.Category;
import com.hci.smarthypermarket.models.Product;

import android.app.ActionBar;
import android.app.Activity;
import android.content.Intent;
import android.graphics.Color;
import android.graphics.drawable.ColorDrawable;
import android.os.Bundle;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.ExpandableListView;
import android.widget.ExpandableListView.OnGroupClickListener;
import android.widget.ExpandableListView.OnGroupCollapseListener;
import android.widget.ExpandableListView.OnGroupExpandListener;


public class BrowseActivity extends Activity {
	
	private ExpandableListView CategoryList;
	private List<Category> CategoryValues;
	private HashMap<Category, List<Product>> ProductValues = new HashMap<Category, List<Product>>();
	
	@Override
	protected void onCreate(Bundle savedInstanceState){
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_browse);
		
		ActionBar ab = getActionBar(); 
        ColorDrawable colorDrawable = new ColorDrawable(Color.rgb(10, 73, 88));     
        ab.setBackgroundDrawable(colorDrawable);
       
        ab.setDisplayShowHomeEnabled(false);
		
		CategoryList = (ExpandableListView) findViewById(R.id.CategoryList);
		CategoryValues = LauncherActivity.market.getCategories();
		
		for(Category cat : this.CategoryValues)
		{
			List <Product>products = cat.getProducts();
			ProductValues.put(cat, products);
		}
		
		
		showCategories(CategoryValues, ProductValues);
		
		CategoryList.setOnGroupClickListener(new OnGroupClickListener() {

			@Override
			public boolean onGroupClick(ExpandableListView arg0, View arg1,
					int arg2, long arg3) {
				// TODO Auto-generated method stub
				return false;
			}
        });
		
		// Listview Group expanded listener
        CategoryList.setOnGroupExpandListener(new OnGroupExpandListener() {
 
            public void onGroupExpand(int groupPosition) {
                /*Toast.makeText(getApplicationContext(),
                		CategoryValues.get(groupPosition) + " Expanded",
                        Toast.LENGTH_SHORT).show();*/
            }
        });
        
        // Listview Group collasped listener
        CategoryList.setOnGroupCollapseListener(new OnGroupCollapseListener() {
 
            public void onGroupCollapse(int groupPosition) {
                /*Toast.makeText(getApplicationContext(),
                		CategoryValues.get(groupPosition) + " Collapsed",
                        Toast.LENGTH_SHORT).show();*/
 
            }
        });

	}

	public BrowseActivity() {
		
	}
	
	public void showCategories(List<Category> categories, HashMap<Category, List<Product>> products)
	{	
		CategoryAdapter adapter = new CategoryAdapter(this, CategoryValues, ProductValues);
		CategoryList.setAdapter(adapter);
	}
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		MenuInflater mif = getMenuInflater();
		mif.inflate(R.menu.browse_actionbar, menu);
		return super.onCreateOptionsMenu(menu);
	}
	
	@Override
	public boolean onOptionsItemSelected(MenuItem item){
		switch(item.getItemId()){
		case R.id.home_icon:
			startDashBoardActivity();
		default:
			return super.onOptionsItemSelected(item);
		}
	}
	
	void startDashBoardActivity(){
		Intent intent = new Intent(BrowseActivity.this, DashBoardActivity.class);
		startActivity(intent);
	}

}
