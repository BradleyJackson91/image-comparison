# ImageComparison

This is a simple console application that utilises the DeepAI image comparison API.

The process takes two separate directories, then compares each image from the first directory with each image in the second directory.
Each comparison pair is sent to the API and a similarity score is returned. 
The application then sorts the results to produce a results list of which images are closest to each other.

The process works, but the ML model is still in training, so the results can be unreliable. An example of this is that a pink picture and a picture of a pig can get a closer matching result than the pink picture compared with the same image, but with the pink changed to a green.

The application was originally written to identify copyright infringements, but due to the results, and the cost to implement against an entire library of images, the project stopped at its current point.

I will be refactoring the code into better quality code and will periodically review the accuracy of the ML model.
