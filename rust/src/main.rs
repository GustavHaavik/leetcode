mod climb_stairs;
use climb_stairs::climb_stairs;

mod excel_sheet_numbes;
use excel_sheet_numbes::convert_to_title;

mod reorganize_string;
use reorganize_string::reorganize_string;

mod text_justification;
use text_justification::full_justify;

fn main() {
    println!("Testing climb_stairs.rs");
    climb_stairs();

    println!("Testing excel_sheet_numbers.rs");
    convert_to_title();

    println!("Testing reorganize_string.rs");
    reorganize_string();

    println!("Testing text_justification.rs");
    full_justify();
}
