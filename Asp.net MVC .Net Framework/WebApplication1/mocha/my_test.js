let assert = chai.assert;
describe('#Adder', function () {
    it('Add should return correctly sum', () => {
        let target = new Modiule1.Adder();
        let res = target.add(1, 1);
        assert.equal(res, 2);
    });
});
