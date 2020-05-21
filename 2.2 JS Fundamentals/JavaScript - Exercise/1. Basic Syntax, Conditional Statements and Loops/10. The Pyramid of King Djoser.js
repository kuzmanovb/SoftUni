function calculateResurcesForPiranid(base, increment) {

    let stone = 0;
    let marble = 0;
    let lapis = 0;
    let gold = 0;

    let count = 0;

    for (let i = base; i > 0; i -= 2) {

        count++;

        let outerLayerBlocks = i > 1 ? i * 4 - 4 : 1;
        let innerBlocks = i * i - outerLayerBlocks;

        let outerLayerBlocksMaterials = outerLayerBlocks  * increment;
        let innerBlocksMaterials = innerBlocks  * increment;

        if (i - 2 < 1) {
            gold = outerLayerBlocksMaterials;
        }
        else if (count % 5 === 0) {
            stone += innerBlocksMaterials;
            lapis += outerLayerBlocksMaterials;
        }
        else {
            stone += innerBlocksMaterials;
            marble += outerLayerBlocksMaterials;
        }
    }

    let heightPiramid = increment * count;

    console.log(`Stone required: ${Math.ceil(stone)}`);
    console.log(`Marble required: ${Math.ceil(marble)}`);
    console.log(`Lapis Lazuli required: ${Math.ceil(lapis)}`);
    console.log(`Gold required: ${Math.ceil(gold)}`);
    console.log(`Final pyramid height: ${Math.floor(heightPiramid)}`);

}

calculateResurcesForPiranid(12, 1);