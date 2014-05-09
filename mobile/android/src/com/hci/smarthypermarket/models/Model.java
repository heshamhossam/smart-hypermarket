package com.hci.smarthypermarket.models;


public abstract class Model {

	public static final String linkServiceRoot = "http://zonlinegamescom.ipage.com/smarthypermarket/public";
	
	protected Boolean isFetched = false;
	protected OnModelListener modelHandler;
	
	protected static Boolean isAllFetched = false;
	protected static OnModelListener OnAllModelsRetrieved;
	
	public Model() {
		
	}
	
	
	public Boolean isAllFetched()
	{
		return isAllFetched;
	}


	public static void setOnAllModelsRetrieved(OnModelListener onAllModelsRetrieved) {
		OnAllModelsRetrieved = onAllModelsRetrieved;
	}


	public void setModelHandler(OnModelListener modelHandler) {
		this.modelHandler = modelHandler;
	}
	

}
