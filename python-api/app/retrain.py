from sklearn.ensemble import IsolationForest
from sklearn.datasets import load_iris
import joblib

def retrain_model():
    iris = load_iris()
    X = iris.data
    model = IsolationForest()
    model.fit(X)
    joblib.dump(model, "app/models/ensemble_model.joblib")

def maybe_retrain():
    # Add logic to check time / conditions for retraining
    retrain_model()
