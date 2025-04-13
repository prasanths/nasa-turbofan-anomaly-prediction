from fastapi import FastAPI, Request
import joblib
import numpy as np
import os
from app.retrain import maybe_retrain  # Optional if retrain logic exists

app = FastAPI()

MODEL_PATH = "app/models/ensemble_model.joblib"
model = joblib.load(MODEL_PATH)
model_last_modified = os.path.getmtime(MODEL_PATH)

def reload_model_if_updated():
    global model, model_last_modified
    current_time = os.path.getmtime(MODEL_PATH)
    if current_time > model_last_modified:
        print("Reloading updated model...")
        model = joblib.load(MODEL_PATH)
        model_last_modified = current_time

@app.post("/predict")
async def predict(request: Request):
    reload_model_if_updated()
    data = await request.json()
    features = np.array(data["features"]).reshape(1, -1)
    prediction = model.predict(features)
    return {"prediction": prediction.tolist()}
