use std::collections::{BinaryHeap, HashMap};

pub fn reorganize_string() {
    let s = String::from("asdasvdfdaaas");
    let result = reorganize(s);
    println!("result: {}", result);
}

fn reorganize(s: String) -> String {
    let mut result: String = String::new();
    let mut map: HashMap<char, i32> = HashMap::new();
    // counts the number of each character
    for c in s.chars() {
        let count: &mut i32 = map.entry(c).or_insert(0);
        // directly increment the count
        *count += 1;
    }

    // The heap is to store the character with the most count
    // The heap is sorted by the count in descending order
    let mut heap: BinaryHeap<(i32, char)> = BinaryHeap::new();
    for (k, v) in map {
        heap.push((v, k));
    }

    while heap.len() > 1 {
        let (v1, k1) = heap.pop().unwrap();
        let (v2, k2) = heap.pop().unwrap();
        result.push(k1);
        result.push(k2);
        if v1 > 1 {
            heap.push((v1 - 1, k1));
        }
        if v2 > 1 {
            heap.push((v2 - 1, k2));
        }
    }

    if let Some((v, k)) = heap.pop() {
        // if the last character has more than 1 count, then it is not possible to reorganize
        if v > 1 {
            return String::new();
        }
        result.push(k);
    }

    result
}
