// Given an integer columnNumber, return its corresponding column title as it appears in an Excel sheet.
pub fn convert_to_title() {
    let column_number = 701;
    let result = convert(column_number);
    println!("result: {}", result);
}

fn convert(column_number: i32) -> String {
    let mut result: String = String::new();
    let mut n: i32 = column_number;
    while n > 0 {
        // subtract 1 to make it 0-indexed
        // then mod 26 because there are 26 letters in the english alphabet
        // as u8 because we want to convert to a char
        // + b'A' because we want to start at A
        let c: u8 = ((n - 1) % 26) as u8 + b'A'; // 0 % 26 = 0 + 65 = 65 = A
        result.push(c as char);
        // divide by 26 to get the next letter
        n = (n - 1) / 26;
    }
    result.chars().rev().collect()
}
