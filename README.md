# Readme

The application running have 3 endpoints:

http://localhost:49591/v1/diff/{id}

This endpoint will compare both encoded data and point the index differences.

http://localhost:49591/v1/diff/{id}/left
http://localhost:49591/v1/diff/{id}/right

Both endpoints receives a data stream. The API is not validating if the data coming is a valid Base64 encoded data, assuming that the client will send the data correctly.
As improvmente, the data validation can be added.

The solution have some unit tests that covers the following:

Unit tests

create and edit
- create an entry *
- check if exists *
- update a value *

diffs
- no values exists to compare *
- only one value exist *
- both values exists and are equal *
- both values exists and have different sizes *
- both values exists, same size but different data *

Improvement Opportunities

- Error Handling
- Incoming Data validation
